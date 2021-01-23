    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public class Program
    {
        public static void Main()
        {
            // required if you use the MetdataType attribute
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(MyItem),
                    typeof(IMyItemValidation)),
                typeof(MyItem));
            var item = new MyItem();
            var context = new ValidationContext(item, 
              serviceProvider: null, 
              items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(item, context, results);
            if (!isValid)
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
            Console.ReadKey();
        }
        [MetadataType(typeof(IMyItemValidation))]
        public class MyItem : IMyItem
        {
            public string cTitle { get; set; }
            public string cDescription { get; set; }
        }
        public interface IMyItem
        {
            string cTitle { get; set; }
            string cDescription { get; set; }
        }
        public interface IMyItemValidation
        {
            [Required]
            string cTitle { get; set; }
            [Required]
            string cDescription { get; set; }
        }
        /* 
        // alternatively you could do either of these as well:
        // Derive MyItem : MyItemBase
        // contains the logic on the base class
        public abstract MyItemBase
            [Required]
            public string cTitle { get; set; }
            [Required]
            public string cDescription { get; set; }
        }
   
        // or
        // Derive MyItem : MyItemBase
        // contains the logic on the base class using MetadataType
        [MetadataType(typeof(IMyItemValidation))]
        public abstract MyItemBase
            public string cTitle { get; set; }
            public string cDescription { get; set; }
        }
    }
