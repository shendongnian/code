    public enum VecozoOverloadedOptions { BSN, InsuranceID, LastName, PostalCode };
    public class VecozoValues
    {
        public string DobFormatted;
        public string infodateFormatted;
        public VecozoOverloadedOptions OverloadChoice;
        public string OverloadedValue;
        public int Homenummer;
        public string Homenummeradd;
        public string InsuranceType;
    }
    ...
    public static string getVecozoURL(VecozoValues data)
    {
       ...
