            try
            {
            }
            catch (System.FormatException FormatEx)
            {
                //logic here
            }
            catch (Exception ex)
            {
                //generic catch-all
                MessageBox(ex.Message);
                throw;
            }
