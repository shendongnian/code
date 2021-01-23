    public override void Input0_ProcessInputRow(Input0Buffer Row)
        {
            /*
             * Add your code here
             */
            using (MD5 md5Hash = MD5.Create())
            {
                //string hash = GetMd5Hash(md5Hash, Row);
                Row.MyOutputColumn = GetMd5Hash(md5Hash, Row);
                //MessageBox.Show(hash);
            }
        }
