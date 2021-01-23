    using System;
    using NHibernate;
    using NHibernate.SqlTypes;
    using NHibernate.UserTypes;
    public class UInt16UserType : IUserType
    {
        public Object NullSafeGet( System.Data.IDataReader rs, String[] names, Object owner )
        {
            Int16? i = (Int16?) NHibernateUtil.Int16.NullSafeGet( rs, names[0] );
            return (UInt16?) i;
        }
        public void NullSafeSet( System.Data.IDbCommand cmd, Object value, int index )
        {
            UInt16? u = (UInt16?) value;
            Int16? i = (Int16?) u;
            NHibernateUtil.Int16.NullSafeSet( cmd, i, index );
        }
        public Type ReturnedType
        {
            get
            {
                return typeof(Nullable<UInt16>);
            }
        }
        public SqlType[] SqlTypes
        {
            get
            {
                return new SqlType[] {SqlTypeFactory.Int16};
            }
        }
        public Object Assemble( Object cached, Object owner )
        {
            return cached;
        }
        public Object DeepCopy( Object value )
        {
            return value;
        }
        public Object Disassemble( Object value )
        {
            return value;
        }
        public int GetHashCode( Object x )
        {
            return x.GetHashCode();
        }
        public bool IsMutable
        {
            get
            {
                return false;
            }
        }
        public Object Replace( Object original, Object target, Object owner )
        {
            return original;
        }
        public new bool Equals( Object x, Object y )
        {
            if (Object.ReferenceEquals( x, y ))
            {
                return true;
            }
            if (x == null || y == null)
            {
                return false;
            }
            if (!(x is UInt16 && y is UInt16))
            {
                return false;
            }
            UInt16 a = (UInt16) x;
            UInt16 b = (UInt16) y;
            bool result = a == b;
            return result;
        }
    }
