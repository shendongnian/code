    public string GetLocalisationCollection()
        {
            CopySoapClient client = new CopySoapClient();
            FieldInformation myFieldInfo = new FieldInformation();
            FieldInformation[] myFieldInfoArray = { myFieldInfo };
            byte[] myByteArray;
            client.GetItem(Configuration.LocalisationUri, out myFieldInfoArray, out myByteArray);
            return System.Text.Encoding.UTF8.GetString(myByteArray);
        }
