    var client = new LabTestClient();
    client.Run<BloodTestFactory,BloodTestType>(BloodTestType.H1AC);
    client.Run<BloodTestFactory,BloodTestType>(BloodTestType.Glucose);
    // outputs
    //   BloodTest: H1AC
    //   BloodTest: Glucose
