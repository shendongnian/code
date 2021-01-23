    public ActionResult GetStudentImage(int studentImageID)
    {
        Student student = studentRepository.Find(studentID);
        return File(student.StudentImage.Image, "image/jpg");
    }
