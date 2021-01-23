    var cd = new System.Net.Mime.ContentDisposition
    {
        FileName = model.Raport.Name.Normalize(NormalizationForm.FormD) + ".csv",
        Inline = false,
    };
