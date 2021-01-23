    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    namespace SoundProvider
    {
        [TestClass]
        public class SoundPathProviderTests
        {
            [ExpectedException(typeof(Exception))]
            [TestMethod]
            public void SoundPathProvider_GetNonExistentSoundPath_ThrowsException()
            {
                var provider = new SoundPathProvider("C:\\Temp\\SoundProviderSource");
                var soundPath = provider.GetSoundPath("NonExistentSound.wav");
            }
            [TestMethod]
            public void SoundPathProvider_GetExistingSoundPath_ThrowsException()
            {
                var provider = new SoundPathProvider("C:\\Temp\\SoundProviderSource");
                var soundPath = provider.GetSoundPath("SampleSound.wav");
                Assert.AreEqual("C:\\Temp\\SoundProviderSource\\SampleSound.wav", soundPath);
            }
        }
    }
