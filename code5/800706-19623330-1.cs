       var frenchvoice = InstalledVoices.All
           .Where(voice => voice.Language.Equals("fr-FR") && 
                  voice.Gender == VoiceGender.Female)
           .FirstOrDefault();
 
