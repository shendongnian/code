            FtpResponse response;
            using (ShimsContext.Create())
            {
                ShimFtpWebRequest.AllInstances.GetResponse = request => new ShimFtpWebResponse();
                ShimFtpWebResponse.AllInstances.StatusDescriptionGet = getDescritpion => "226 Transfer complete.";
                _ftpConnection.Put(_fileContent);
                response = new FtpResponse("226 Transfer complete.", false);
            }
            Assert.AreEqual(response.Message, "226 Transfer complete.");
            Assert.IsFalse(response.HasError);
