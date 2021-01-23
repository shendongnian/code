    public static void updateTable1(string myNameRange, string mySET, string myWHERE)
        {
            if (Check()==0)/// Suppose 0 means all textboxes filled and name2 exists in DB
           {      
            string sql = "UPDATE myTable SET  NAME=@name , AGE=@age  WHERE Name=@name2";
           
            myCommand.CommandText = sql;
            myCommand.Parameters.AddWithValue("@name", textBox1.text);
            myCommand.Parameters.AddWithValue("@age", textBox2.text);
            myCommand.Parameters.AddWithValue("@name2", textBox3.text);
            myCommand.ExecuteNonQuery();
            }
            else if  (Check()==1)/// Suppose 1 means only name filled and name2 exists in DB
            {
              string sql = "UPDATE myTable SET  NAME=@name  WHERE Name=@name2";      
            myCommand.CommandText = sql;
            myCommand.Parameters.AddWithValue("@name", textBox1.text);       
            myCommand.Parameters.AddWithValue("@name2", textBox3.text);
            myCommand.ExecuteNonQuery();
            }
            ....
            else /// (name2 not in DB)
            {
             sql = "INSERT INTO" + myNameRange + " SET " + mySET + "'";
              ///.......
            }
        }
