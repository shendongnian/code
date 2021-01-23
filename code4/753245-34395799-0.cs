            // Initialize SourceAFIS
            if (Afis == null) Afis = new AfisEngine();
            // Enroll fitst identity
            Fingerprint f = new Fingerprint();
            f.AsBitmap = (Bitmap)pictureBoxFinger.Image;
            
            Person probe = new Person();
            probe.Fingerprints.Add(f);
            Afis.Extract(probe);
            // Enroll second identity            
            Fingerprint f2 = new Fingerprint();
            f2.AsBitmap = (Bitmap)pictureBoxVerify.Image;
            Person match = new Person();
            match.Fingerprints.Add(f2);
            Afis.Extract(match);
            // Compute similarity score
            float score = Afis.Verify(probe, match);
