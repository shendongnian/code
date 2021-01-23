     public class MyData
     {
         public string Text;
         public SqlDbType Type;
         public int Number;
         public MyData(string text, SqlDbType type, int number = 0)
         {
             Text = text;
             Type = type;
             Number = number;
         }
     }
     MyData[] data = new MyData[45] { new MyData("@bOutput", SqlDbType.VarChar), new MyData(...), ... };
     TextBox[] control = new TextBox[45] {textBox1, textBox2, ... };
     for(int i = 0; i < 45; i++)
         cmd.Parameters.Add(data[i].Text, data[i].Type, data[i].Number).Value = control[i].Text;
