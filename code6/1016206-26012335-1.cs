        public delegate object AllergiesDelegate(
            long patientAccount, long chartId, bool isCf, string practiceCode = "");
        static void Main(string[] args)
        {
            AllergiesDelegate allergies = null;
            IAsyncResult Allergies = allergies.BeginInvoke(0, 0, false, "", null, null);
        }
