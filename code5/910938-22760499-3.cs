    struct Question
    {
        public readonly int Temakor;
        public readonly int KerdesInt32;
        public readonly string Kerdes, KerdesA, KerdesB, KerdesC, KerdesD
        public readonly char Valasz;
        public Question(int temakor, int kerdesInt32, ..., char valasz)
        {
            Temakor = temakor;
            KerdesInt32 = kerdesInt32;
            // ...
            Valasz = valasz;
        }
     }
