        catch (Exception eX)
        {
            personsList = null;
        }
        finally
        {
            if (connection != null)
            {
                connection.Close();
            }
           
        }
     return personsList;
 
