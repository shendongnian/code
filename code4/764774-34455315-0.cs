    namespace System.Security.Cryptography
    {
    using System.Globalization;
    using System.IO;
    using System.Text;
    [System.Runtime.InteropServices.ComVisible(true)]
    public class Rfc2898DeriveBytes_HMACSHA512 : DeriveBytes
    {
        private byte[] m_buffer;
        private byte[] m_salt;
        private HMACSHA512 m_HMACSHA512;  // The pseudo-random generator function used in PBKDF2
        private uint m_iterations;
        private uint m_block;
        private int m_startIndex;
        private int m_endIndex;
        private static RNGCryptoServiceProvider _rng;
        private static RNGCryptoServiceProvider StaticRandomNumberGenerator
        {
            get
            {
                if (_rng == null)
                {
                    _rng = new RNGCryptoServiceProvider();
                }
                return _rng;
            }
        }
        private const int BlockSize = 20;
        //
        // public constructors 
        // 
        public Rfc2898DeriveBytes_HMACSHA512(string password, int saltSize) : this(password, saltSize, 1000) { }
        public Rfc2898DeriveBytes_HMACSHA512(string password, int saltSize, int iterations)
        {
            if (saltSize < 0)
                throw new ArgumentOutOfRangeException("saltSize", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
            byte[] salt = new byte[saltSize];
            StaticRandomNumberGenerator.GetBytes(salt);
            Salt = salt;
            IterationCount = iterations;
            m_HMACSHA512 = new HMACSHA512(new UTF8Encoding(false).GetBytes(password));
            Initialize();
        }
        public Rfc2898DeriveBytes_HMACSHA512(string password, byte[] salt) : this(password, salt, 1000) { }
        public Rfc2898DeriveBytes_HMACSHA512(string password, byte[] salt, int iterations) : this(new UTF8Encoding(false).GetBytes(password), salt, iterations) { }
        public Rfc2898DeriveBytes_HMACSHA512(byte[] password, byte[] salt, int iterations)
        {
            Salt = salt;
            IterationCount = iterations;
            m_HMACSHA512 = new HMACSHA512(password);
            Initialize();
        }
        //
        // public properties 
        //
        public int IterationCount
        {
            get { return (int)m_iterations; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("value", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
                m_iterations = (uint)value;
                Initialize();
            }
        }
        public byte[] Salt
        {
            get { return (byte[])m_salt.Clone(); }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (value.Length < 8)
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Cryptography_PasswordDerivedBytes_FewBytesSalt")));
                m_salt = (byte[])value.Clone();
                Initialize();
            }
        }
        // 
        // public methods
        // 
        public override byte[] GetBytes(int cb)
        {
            if (cb <= 0)
                throw new ArgumentOutOfRangeException("cb", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum"));
            byte[] password = new byte[cb];
            int offset = 0;
            int size = m_endIndex - m_startIndex;
            if (size > 0)
            {
                if (cb >= size)
                {
                    Buffer.InternalBlockCopy(m_buffer, m_startIndex, password, 0, size);
                    m_startIndex = m_endIndex = 0;
                    offset += size;
                }
                else
                {
                    Buffer.InternalBlockCopy(m_buffer, m_startIndex, password, 0, cb);
                    m_startIndex += cb;
                    return password;
                }
            }
            //BCLDebug.Assert(m_startIndex == 0 && m_endIndex == 0, "Invalid start or end index in the internal buffer.");
            while (offset < cb)
            {
                byte[] T_block = Func();
                int remainder = cb - offset;
                if (remainder > BlockSize)
                {
                    Buffer.InternalBlockCopy(T_block, 0, password, offset, BlockSize);
                    offset += BlockSize;
                }
                else
                {
                    Buffer.InternalBlockCopy(T_block, 0, password, offset, remainder);
                    offset += remainder;
                    Buffer.InternalBlockCopy(T_block, remainder, m_buffer, m_startIndex, BlockSize - remainder);
                    m_endIndex += (BlockSize - remainder);
                    return password;
                }
            }
            return password;
        }
        public override void Reset()
        {
            Initialize();
        }
        private void Initialize()
        {
            if (m_buffer != null)
                Array.Clear(m_buffer, 0, m_buffer.Length);
            m_buffer = new byte[BlockSize];
            m_block = 1;
            m_startIndex = m_endIndex = 0;
        }
        internal static byte[] Int(uint i)
        {
            byte[] b = BitConverter.GetBytes(i);
            byte[] littleEndianBytes = { b[3], b[2], b[1], b[0] };
            return BitConverter.IsLittleEndian ? littleEndianBytes : b;
        }
        // This function is defined as follow : 
        // Func (S, i) = HMAC(S || i) | HMAC2(S || i) | ... | HMAC(iterations) (S || i)
        // where i is the block number. 
        private byte[] Func()
        {
            byte[] INT_block = Int(m_block);
            m_HMACSHA512.TransformBlock(m_salt, 0, m_salt.Length, m_salt, 0);
            m_HMACSHA512.TransformFinalBlock(INT_block, 0, INT_block.Length);
            byte[] temp = m_HMACSHA512.Hash;
            m_HMACSHA512.Initialize();
            byte[] ret = temp;
            for (int i = 2; i <= m_iterations; i++)
            {
                temp = m_HMACSHA512.ComputeHash(temp);
                for (int j = 0; j < BlockSize; j++)
                {
                    ret[j] ^= temp[j];
                }
            }
            // increment the block count.
            m_block++;
            return ret;
        }
    }
    }
