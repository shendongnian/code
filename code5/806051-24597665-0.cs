    private bool check_file_oppen(string check)
        {//where string check is the path of required file
            try
            {
                Stream s = File.Open(check, FileMode.Open, FileAccess.Read, FileShare.None);
                s.Close();
                MessageBox.Show("FILE IS NOT OPEN");
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("FILE IS OPEN");
                
                return false;
            }
        }
