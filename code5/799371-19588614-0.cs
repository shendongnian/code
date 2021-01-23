    namespace MyNamespace
    {
        class Student
        {
            public string Name { get; set; }
            public int PhoneNumber { get; set; }
            public string Address { get; set; }
            public string Occupation { get; set; }
            public string CourseOfStudy { get; set; }
            public int Duration { get; set; }
            public string UploadPicture { get; set; }
            public Student() : this("", 0, "", "", "", 0, "")
            {
                MessageBox.Show("Called Constructor");
            }
            public Student(String name, int phoneNo, string address, string occupation, string courseOfStudy, int duration, string uploadPicture)
            {
                Name = name;
                PhoneNumber = phoneNo;
                Address = address;
                Occupation = occupation;
                CourseOfStudy = courseOfStudy;
                Duration = duration;
                UploadPicture = uploadPicture;
            }
        }
    }
