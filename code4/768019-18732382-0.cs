    [Test]
    public void Will_Calculate_Correct_Weight_For_Woman()
    {
       patientinfo p3 = new patientinfo();//set appropruate values here
       //Example: p3.Gender = "Woman"; or p3.setGender("Woman");
       double result = someClass.weightCalc(p3);
       Assert.AreEqual(110,result);
    }
