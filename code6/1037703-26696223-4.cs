    public class Payment {
        public string Name {get;set;}
        public DateTime previousPayment {get;set;}
        public DateTime nextPayment {get;set;}
        public GetNextPayment(){
            // code to get the next payment
            this.previousPayment = //whatever
            this.nextPayment = //whatever
        }
    }
