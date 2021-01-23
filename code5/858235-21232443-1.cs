    Dim sql As String = "INSERT INTO Information VALUES(@name,@photo)"
    Dim cmd As New SqlCommand(sql, con)
    cmd.Parameters.AddWithValue("@name", "DepartmentName")
    Dim ms As New MemoryStream()
    ms.Read(imageToByteArray(gv.Rows(0).Cells(4).Value), 0, 1024)
    Dim data As Byte() = ms.GetBuffer()
    Dim p As New SqlParameter("@photo", SqlDbType.Image)
    p.Value = data
    cmd.Parameters.Add(p)
    cmd.ExecuteNonQuery()
    MessageBox.Show("Name & Image has been saved", "Save", MessageBoxButtons.OK)
    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
     MemoryStream ms = new MemoryStream();
     imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
     return  ms.ToArray();
    }
