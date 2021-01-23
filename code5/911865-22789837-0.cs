       void Read_Order_Data()
        {
           FileStream fs = new FileStream("i:\\OrderData.txt", FileMode.Open, FileAccess.Read);
           StreamReader reader = new StreamReader(fs);
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] fields = line.Split('#');
            if (fields.length == 4){
               Order[Number_Of_Orders].Order_Number = fields[0];
               Order[Number_Of_Orders].Type_Of_Bean = fields[1];
               Order[Number_Of_Orders].Quantity_Of_Order = fields[2];
               Order[Number_Of_Orders].Date_Of_Purchase = fields[3];
               Number_Of_Orders++;
            }
        }//end of while statement
        reader.Close();
    }//end of Read_Order_Data()
