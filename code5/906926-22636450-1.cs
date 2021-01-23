        [TestMethod]
        public void DeleteOldestFilesTest()
        {
            const string driveLetter = "C:\\";
            const string path = "C:\\Users\\user\\FileCleanerTest";
            var drive = DriveInfo.GetDrives().Where(d => d.IsReady).Single(d => d.Name == driveLetter);
            var availableSpace = drive.TotalFreeSpace;
            var neededSpace = availableSpace + 10000;
            HdCleaner.DeleteOldestFiles(neededSpace,  path);
            var newAvailableSpace = drive.TotalFreeSpace;
            Assert.IsTrue(newAvailableSpace >= neededSpace);
        }
