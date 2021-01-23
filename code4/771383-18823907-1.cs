    public void test(ref string ErrMsg )
    {
    
        ErrMsg = string.Empty;
         try
            {
                int num = int.Parse("gagw");
            }
            catch (Exception ex)
            {
                ErrMsg = ex.Message;
            }
    }
