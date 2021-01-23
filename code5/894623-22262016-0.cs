    private void verify(HtmlControl obj, int timeout)
    {
        try
        {
            for (int i = 0; i < timeout; i++)
            {
                obj.Wait.ForExists();
                //break;
            }
        }
        catch (Exceptions.FindElementException ex)
        {
            Debug.WriteLine("Could Not Verify Object" + obj + "Exists.  Exception: " + ex);
        }
        catch {} // PUT THE BREAKPOINT HERE
    }
