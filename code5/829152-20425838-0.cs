    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi)]
    public struct _H_cardData_MG {
        
        /// int
        public int cardCode;
        
        /// int
        public int credit;
        
        /// int
        public int minCredit;
        
        /// WORD->unsigned short
        public ushort reserved01;
        
        /// WORD->unsigned short
        public ushort endUserCode;
        
        /// WORD->unsigned short
        public ushort password;
        
        /// BYTE->unsigned char
        public byte groupCode;
        
        /// cardType : 2
        ///disabled : 1
        ///outOfCtrlDirection : 1
        ///bonusUsage : 2
        ///AnonymousMember1 : 2
        public uint bitvector1;
        
        /// char[16]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=16)]
        public string name;
        
        /// _H_lastAccess_MF[4]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=4, ArraySubType=System.Runtime.InteropServices.UnmanagedType.Struct)]
        public _H_lastAccess_MF[] appData;
        
        /// BYTE->unsigned char
        public byte creditMultipler;
        
        /// BYTE->unsigned char
        public byte bonusRatio;
        
        /// BYTE->unsigned char
        public byte reserved02;
        
        /// BYTE->unsigned char
        public byte reserved03;
        
        /// int
        public int bonus;
        
        /// BYTE[4]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst=4, ArraySubType=System.Runtime.InteropServices.UnmanagedType.I1)]
        public byte[] reserved04;
        
        public uint cardType {
            get {
                return ((uint)((this.bitvector1 & 3u)));
            }
            set {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }
        
        public uint disabled {
            get {
                return ((uint)(((this.bitvector1 & 4u) 
                            / 4)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 4) 
                            | this.bitvector1)));
            }
        }
        
        public uint outOfCtrlDirection {
            get {
                return ((uint)(((this.bitvector1 & 8u) 
                            / 8)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 8) 
                            | this.bitvector1)));
            }
        }
        
        public uint bonusUsage {
            get {
                return ((uint)(((this.bitvector1 & 48u) 
                            / 16)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 16) 
                            | this.bitvector1)));
            }
        }
        
        public uint AnonymousMember1 {
            get {
                return ((uint)(((this.bitvector1 & 192u) 
                            / 64)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 64) 
                            | this.bitvector1)));
            }
        }
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct _H_lastAccess_MF {
        
        /// lastUsedHourMin : 11
        ///in : 1
        ///AnonymousMember1 : 4
        public uint bitvector1;
        
        /// SHORT->short
        public short lastUsedDate;
        
        /// wStart : 11
        ///limitCnt : 3
        ///AnonymousMember2 : 2
        ///wEnd : 11
        ///limitMax : 3
        ///AnonymousMember3 : 2
        public uint bitvector2;
        
        /// WORD->unsigned short
        public ushort expireDate;
        
        /// expireHourMin : 11
        ///prePaymentCredit : 5
        public uint bitvector3;
        
        public uint lastUsedHourMin {
            get {
                return ((uint)((this.bitvector1 & 2047u)));
            }
            set {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }
        
        public uint @in {
            get {
                return ((uint)(((this.bitvector1 & 2048u) 
                            / 2048)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 2048) 
                            | this.bitvector1)));
            }
        }
        
        public uint AnonymousMember1 {
            get {
                return ((uint)(((this.bitvector1 & 61440u) 
                            / 4096)));
            }
            set {
                this.bitvector1 = ((uint)(((value * 4096) 
                            | this.bitvector1)));
            }
        }
        
        public uint wStart {
            get {
                return ((uint)((this.bitvector2 & 2047u)));
            }
            set {
                this.bitvector2 = ((uint)((value | this.bitvector2)));
            }
        }
        
        public uint limitCnt {
            get {
                return ((uint)(((this.bitvector2 & 14336u) 
                            / 2048)));
            }
            set {
                this.bitvector2 = ((uint)(((value * 2048) 
                            | this.bitvector2)));
            }
        }
        
        public uint AnonymousMember2 {
            get {
                return ((uint)(((this.bitvector2 & 49152u) 
                            / 16384)));
            }
            set {
                this.bitvector2 = ((uint)(((value * 16384) 
                            | this.bitvector2)));
            }
        }
        
        public uint wEnd {
            get {
                return ((uint)(((this.bitvector2 & 134152192u) 
                            / 65536)));
            }
            set {
                this.bitvector2 = ((uint)(((value * 65536) 
                            | this.bitvector2)));
            }
        }
        
        public uint limitMax {
            get {
                return ((uint)(((this.bitvector2 & 939524096u) 
                            / 134217728)));
            }
            set {
                this.bitvector2 = ((uint)(((value * 134217728) 
                            | this.bitvector2)));
            }
        }
        
        public uint AnonymousMember3 {
            get {
                return ((uint)(((this.bitvector2 & 3221225472u) 
                            / 1073741824)));
            }
            set {
                this.bitvector2 = ((uint)(((value * 1073741824) 
                            | this.bitvector2)));
            }
        }
        
        public uint expireHourMin {
            get {
                return ((uint)((this.bitvector3 & 2047u)));
            }
            set {
                this.bitvector3 = ((uint)((value | this.bitvector3)));
            }
        }
        
        public uint prePaymentCredit {
            get {
                return ((uint)(((this.bitvector3 & 63488u) 
                            / 2048)));
            }
            set {
                this.bitvector3 = ((uint)(((value * 2048) 
                            | this.bitvector3)));
            }
        }
    }
