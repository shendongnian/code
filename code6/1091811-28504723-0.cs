         try
            {
                var client = new HttpClient();
                //Converting to HTTP content since postasync below needs it...
                HttpContent myHttpContent = new StringContent(requestData);
                //Creating the ContentType header.....
                myHttpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //Sending the POST request to create a thread post ....
                HttpResponseMessage APIRequest = await client.PostAsync(url, myHttpContent);
                if (APIRequest.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // Read the HTTP response content....
                    HttpContent responseContent = APIRequest.Content;
                    // Read the response content as string.....
                    return await responseContent.ReadAsStringAsync();
                }
                if (APIRequest.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    // Read the HTTP response content....
                    HttpContent responseContent = APIRequest.Content;
                    // Read the response content as string.....
                    return await responseContent.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("Error connecting to " + url + " ! Status: " + APIRequest.StatusCode);
                }
            }
            catch (Exception ex)
            {
                //Display your custom error message
            }
            finally
            {
                //Instantiate the controls class for using the progress bar and other controls in this function...
                myControls mycontrols = new myControls();
                //Instantiate the frames class for using in this function since this.Frame.Navigate can't be used...
                Frame myframe = new Frame();
                mycontrols.popupMessages(errorMessage, "Network or Server error!");
                //mycontrols.popupMessages("There was an issue getting your messages from the Message Center, please try again later", "Network or Server error!");
                //Navigate back to the main page....
                myframe.Navigate(typeof(MainPage));
            }
           
        }
