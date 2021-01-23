        if (responseMessage.IsSuccessStatusCode)
        {
            // Here you should process your response if it is successfull.
            // Something like
            // var result = await responseMessage.Content.ReadAsAsync<MyClass>();
        }
        else
        {
            var errorContent = await responseMessage.Content.ReadAsStringAsync();
            // "errorContent" variable will contain your exception message.
        }
