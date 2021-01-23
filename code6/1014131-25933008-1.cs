    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
            public override bool Equals(Object obj) {
                if (this == null)                        //this is necessary to guard against reverse-pinvokes and
                    throw new NullReferenceException();  //other callers who do not use the callvirt instruction
     
                String str = obj as String;
                if (str == null)
                    return false;
     
                if (Object.ReferenceEquals(this, obj))
                    return true;
     
                if (this.Length != str.Length)
                    return false;
     
                return EqualsHelper(this, str);
            }
