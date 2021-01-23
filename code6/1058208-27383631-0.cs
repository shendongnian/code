    catch (OleDbException e)
    { 
        switch (dbException.Errors[0].SQLState)
        {
            case "3376":
                MessageBox.Show(dbException.Errors[0].Message); // or any message
                break;
            default:
                MessageBox.Show(e.Message);
        }
    }
