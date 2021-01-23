    const string sql = @"
    insert into tblMedicineHistory (PatientID, MedicineName, MedicineType, ...)
    values(@patientId, @medicineName, @medicineType, ...)";
    var args = new[] {
        new SqlParameter("@patientId", PatientId),
        new SqlParameter("@medicineName", MedicineName),
        new SqlParameter("@medicineType", MedicineType),
        ...
    }
