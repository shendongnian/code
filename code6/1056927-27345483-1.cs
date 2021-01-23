    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Accounting
    {
        public static Accounting Current
        {
            get
            {
                return (HttpContext.Current.Items["Accounting"] ??
                    (HttpContext.Current.Items["Accounting"] = 
                    new Accounting())) as Accounting;
    
            }
        }
        public String currentFile = "";
        public List<string> PurchaseOrder = new List<string>();
        public List<string> item = new List<string>();
        public List<string> unitPrice = new List<string>();
        public List<string> shippingCharge = new List<string>();
        public List<string> handlingCharge = new List<string>();
        public List<string> discountAmount = new List<string>();
        public List<string> UOM = new List<string>();
        public List<string> invoiceNumber = new List<string>();
        public List<string> supplierNumber = new List<string>(); //{ get; set; }
        public List<string> supplierInvoiceNo = new List<string>();
        public List<string> account = new List<string>();
        public List<string> fund = new List<string>();
        public List<string> org = new List<string>();
        public List<string> prog = new List<string>();
        public List<string> activity = new List<string>();
        public List<string> location = new List<string>();
        public List<string> distributionType = new List<string>();
        public List<string> distributionValue = new List<string>();
        public List<int> sequence = new List<int>();
        public List<string> quantity = new List<string>();
        public List<string> dueDate = new List<string>();
    }
