    public EmployeeProfile(int EmpID)
    {
          if (Emp != null && Emp.Photo != null)
          {
               pictureBoxEmp.Image = byteArrayToImage(Emp.Photo.ToArray());
               pictureBoxEmp.SizeMode = PictureBoxSizeMode.StretchImage;
          }
    }
