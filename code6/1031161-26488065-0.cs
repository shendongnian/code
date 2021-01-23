    class Program {
        static void Main(string[] args) {
            pricingdemoEntities demo = new pricingdemoEntities();
            demo.demotables.RemoveAll(x => x.value == "array");
            demo.SaveChanges();
        }
    }
