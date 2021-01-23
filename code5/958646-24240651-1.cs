        //....
        var responseObject = JsonConvert.DeserializeObject<RootObject>(responseText);
    }
    
    public class IosInfo
    {
        public string serialNumber { get; set; }
        public string imeiNumber { get; set; }
        public string meid { get; set; }
        public string iccID { get; set; }
        public string firstUnbrickDate { get; set; }
        public string lastUnbrickDate { get; set; }
        public string unbricked { get; set; }
        public string unlocked { get; set; }
        public string productVersion { get; set; }
        public string initialActivationPolicyID { get; set; }
        public string initialActivationPolicyDetails { get; set; }
        public string appliedActivationPolicyID { get; set; }
        public string appliedActivationDetails { get; set; }
        public string nextTetherPolicyID { get; set; }
        public string nextTetherPolicyDetails { get; set; }
        public string macAddress { get; set; }
        public string bluetoothMacAddress { get; set; }
        public string partDescription { get; set; }
    }
    
    public class ConsumerLawInfo
    {
        public string serviceType { get; set; }
        public string popMandatory { get; set; }
        public string allowedPartType { get; set; }
    }
    
    public class ProductInfo
    {
        public string serialNumber { get; set; }
        public string warrantyStatus { get; set; }
        public string coverageEndDate { get; set; }
        public string coverageStartDate { get; set; }
        public string daysRemaining { get; set; }
        public string estimatedPurchaseDate { get; set; }
        public string purchaseCountry { get; set; }
        public string registrationDate { get; set; }
        public string imageURL { get; set; }
        public string explodedViewURL { get; set; }
        public string manualURL { get; set; }
        public string productDescription { get; set; }
        public string configDescription { get; set; }
        public string slaGroupDescription { get; set; }
        public string contractCoverageEndDate { get; set; }
        public string contractCoverageStartDate { get; set; }
        public string contractType { get; set; }
        public string laborCovered { get; set; }
        public string limitedWarranty { get; set; }
        public string partCovered { get; set; }
        public string notes { get; set; }
        public string acPlusFlag { get; set; }
        public ConsumerLawInfo consumerLawInfo { get; set; }
    }
    
    public class RootObject
    {
        public IosInfo ios_info { get; set; }
        public ProductInfo product_info { get; set; }
    }
