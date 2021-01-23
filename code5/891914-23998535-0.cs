            // Connect to translator service
            SpeechSynthesizer speech = new SpeechSynthesizer("clientID", "secretKey");
            speech.AudioFormat = SpeakStreamFormat.MP3;
            speechStream = speech.GetSpeakStream(text, language);
            // Write it out to the stream
            Response.Clear();
            Response.ContentType = "audio/mp3";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + "");
            speechStream.CopyTo(Response.OutputStream);
            Response.Flush();
