    async private void ChangeImage()
    {
        // Loop through each of the tests
        foreach (var testLight in imageDictionary)
        {
            ChangeImageLights(testLight.Value);
            await Task.Delay(1000);
        }
    }
