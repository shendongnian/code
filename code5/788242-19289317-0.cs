    object[] values)
    {
        this.BeginUpdate();
        for (int i = 0; i < 9; i++)
        {
            try
            {
                this.SetTag(TagHandle[i], (values[i]), Quality.Good, FileTime.UtcNow);
            }
            catch (Exception e)
            {
                // Log or print out the details
                Console.WriteLine("Error occurred setting the value.");
                Console.WriteLine(e);
            }
        }
        this.EndUpdate(false);
    }
