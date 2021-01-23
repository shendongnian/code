        /// <summary>
        /// Returns the classfull subnet mask of a given IPv4 network
        /// </summary>
        /// <param name="ipa">The network to get the classfull subnetmask for</param>
        /// <returns>The classfull subnet mask of a given IPv4 network</returns>
        public static Subnetmask GetClassfullSubnetMask(IPAddress ipa)
        {
            if (ipa.AddressFamily != AddressFamily.InterNetwork)
            {
                throw new ArgumentException("Only IPv4 addresses are supported for classfull address calculations.");
            }
            IPv4AddressClass ipv4Class = GetClass(ipa);
            Subnetmask sm = new Subnetmask();
            if (ipv4Class == IPv4AddressClass.A)
            {
                sm.MaskBytes[0] = 255;
            }
            if (ipv4Class == IPv4AddressClass.B)
            {
                sm.MaskBytes[0] = 255;
                sm.MaskBytes[1] = 255;
            }
            if (ipv4Class == IPv4AddressClass.C)
            {
                sm.MaskBytes[0] = 255;
                sm.MaskBytes[1] = 255;
                sm.MaskBytes[2] = 255;
            }
            return sm;
        }
