       using System.Data;
       //...
       string myString = "20";
       string addition = "+ 2";
       DataTable dt = new DataTable();
        
       myString = dt.Compute(myString + addition, string.Empty).ToString();
