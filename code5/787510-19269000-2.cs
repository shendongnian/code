            HttpWebRequest request = (HttpWebRequest)asynchronousResult.AsyncState;
            // End the operation
            HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(asynchronousResult);
            Stream streamResponse = response.GetResponseStream();
            StreamReader streamRead = new StreamReader(streamResponse);
            string read = streamRead.ReadToEnd();
            //respond from httpRequest
            TextBox.Text = read;
            // Close the stream object
            streamResponse.Close();
            streamRead.Close();
            response.Close();
}
   `
   
