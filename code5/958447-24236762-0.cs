    Dim t = New System.Threading.Thread(Sub()
        Dim ss As New SpeechSynthesizer()
        Using memoryStream As New MemoryStream()
            ss.SetOutputToWaveStream(memoryStream)
            ss.Speak(textToSpeak)
            byteArr = memoryStream.ToArray()
        End Using
    End Sub)
