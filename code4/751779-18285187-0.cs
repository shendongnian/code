    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        public class Photo
        {
            public Int32 PhotoId { get; set; }
            public Guid ObjectKey { get; set; }
            public Int16 Width { get; set; }
            public Int16 Height { get; set; }
            public Int32 CategoryId { get; set; }
       
            public static Photo Load(int id)
            {
                using (SqlConnection conn = new SqlConnection("ABC"))
                {
                    return conn.Get<Photo>(id);
                }
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                Photo photo = Photo.Load(1);
            }
        }
    }
