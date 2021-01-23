    public EmployeeProfile(int EmpID)
            {
                  if (Emp.Photo != null)
                        {
                            pictureBoxEmp.Image = byteArrayToImage(Emp.Photo.ToArray());
                            pictureBoxEmp.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
            }
