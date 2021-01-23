            private static int i = 0;
            private static string str = string.Empty;
            protected void btn_Showelements_Click(object sender, EventArgs e)
            {
                string[] arr = new string[4] { "a", "b", "c", "d" };
    
                if (i < arr.Length)
                {
                    str += arr[i];
    
                    i++;
                    tb_ShowElement.Text = str.ToString();
                }
            }
