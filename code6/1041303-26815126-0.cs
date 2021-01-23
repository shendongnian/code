     public class MyBarcodeRow
        {
            private String barcode = String.Empty;
    
            public String Barcode
            {
                get { return barcode; }
                set { 
                    
                    barcode = value;
                    ////TODO OPERATION ON OTHER FIELD
                    //FOR EXAMPLE GET DATA OF QUANTITY FROM DATABASE
    
                    this.Quantity = new Random().Next(Int32.MaxValue);
                }
            }
    
            private int quantity = 0;
    
            public int Quantity
            {
                get { return quantity; }
                set { quantity = value; }
            }
    
            //AND OTHER FIELD
    
        }
