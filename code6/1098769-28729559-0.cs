    private void button5_Click(object sender, EventArgs e)
    {
        try
        {
            int freeCount = 0;
            while(Call_DLL.GetModuleHandle("DLL.dll") != System.IntPtr.Zero)
            {
                 Call_DLL.FreeLibrary(SystemIntPtr_handle_of_DLL);
                 freeCount++;
            }
            MessageBox.Show("DLL unloaded. You will have to load it again. (Unloaded" + int_FreeLibrary_counter + " times)");
         }
         catch(Exception Exception_Object)
         {
            MessageBox.Show(Exception_Object.Message);
         }
    }
