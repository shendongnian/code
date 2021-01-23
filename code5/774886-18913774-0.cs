    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    public class Entity { }
    public class CalculationBasis { }
    public class PeriodSelectionType { }
    [Serializable]
    public class Business : Entity
    {
        public virtual string TemplateName { get; set; }
        public virtual CalculationBasis CalculationBasis { get; set; }
        public virtual PeriodSelectionType PeriodSelectionType { get; set; }
        public virtual DateTime PeriodEndDate { get; set; }
        public virtual IEnumerable<int> mainKeys { get; set; }
    }
    class program
    {
        static void Main()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
    
            var ObjectOfBusiness = new Business
            {
                TemplateName = "abc",
                CalculationBasis = new CalculationBasis(),
                PeriodSelectionType = new PeriodSelectionType(),
                PeriodEndDate = new DateTime(),
                mainKeys = new int[] { 1, 2, 3, 4, 5 }
            };
            var strJson = JsonConvert.SerializeObject(ObjectOfBusiness, settings);
            //...
            var obj = JsonConvert.DeserializeObject<Business>(strJson, settings);
            // ^^^^ all good
        }
    }
