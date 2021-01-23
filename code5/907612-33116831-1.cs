    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Gists.Extensions.ListOfTExtentions;
    namespace Gists_Tests.ExtensionTests.ListOfTExtentionTests
    {
        [TestClass]
        public class ListOfT_ToDelimitedTextTests
        {
            #region Mock Data
            private class SimpleObject
            {
                public int Id { get; set; }
            }
            private class ComplextObject : SimpleObject
            {
                public string Name { get; set; }
                public bool Active { get; set; }
            }
            #endregion
            #region Tests
            [TestMethod]
            public void ToDelimitedText_ReturnsCorrectNumberOfRows()
            {
                // ARRANGE
                var itemList = new List<ComplextObject>
                {
                    new ComplextObject {Id = 1, Name = "Sid", Active = true},
                    new ComplextObject {Id = 2, Name = "James", Active = false},
                    new ComplextObject {Id = 3, Name = "Ted", Active = true},
                };
                const string delimiter = ",";
                const int expectedRowCount = 3;
                const bool trimTrailingNewLineIfExists = true;
                // ACT
                string result = itemList.ToDelimitedText(delimiter, trimTrailingNewLineIfExists);
                var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                var actualRowCount = lines.Length;
                // ASSERT
                Assert.AreEqual(expectedRowCount, actualRowCount);
            }
            [TestMethod]
            public void ToDelimitedText_ReturnsCorrectNumberOfProperties()
            {
                // ARRANGE
                var itemList = new List<ComplextObject>
                {
                    new ComplextObject {Id = 1, Name = "Sid", Active = true}
                };
                const string delimiter = ",";
                const int expectedPropertyCount = 3;
                // ACT
                string result = itemList.ToDelimitedText(delimiter);
                var lines = result.Split(Environment.NewLine.ToCharArray());
                var properties = lines.First().Split(delimiter.ToCharArray());
                var actualPropertyCount = properties.Length;
                // ASSERT
                Assert.AreEqual(expectedPropertyCount, actualPropertyCount);
            }
            [TestMethod]
            public void ToDelimitedText_RemovesTrailingNewLine_WhenSet()
            {
                // ARRANGE
                var itemList = new List<ComplextObject>
                {
                    new ComplextObject {Id = 1, Name = "Sid", Active = true},
                    new ComplextObject {Id = 2, Name = "James", Active = false},
                    new ComplextObject {Id = 3, Name = "Ted", Active = true},
                };
                const string delimiter = ",";
                const bool trimTrailingNewLineIfExists = true;
                // ACT
                string result = itemList.ToDelimitedText(delimiter, trimTrailingNewLineIfExists);
                bool endsWithNewLine = result.EndsWith(Environment.NewLine);
                // ASSERT
                Assert.IsFalse(endsWithNewLine);
            }
            [TestMethod]
            public void ToDelimitedText_IncludesTrailingNewLine_WhenNotSet()
            {
                // ARRANGE
                var itemList = new List<ComplextObject>
                {
                    new ComplextObject {Id = 1, Name = "Sid", Active = true},
                    new ComplextObject {Id = 2, Name = "James", Active = false},
                    new ComplextObject {Id = 3, Name = "Ted", Active = true},
                };
                const string delimiter = ",";
                const bool trimTrailingNewLineIfExists = false;
                // ACT
                string result = itemList.ToDelimitedText(delimiter, trimTrailingNewLineIfExists);
                bool endsWithNewLine = result.EndsWith(Environment.NewLine);
                // ASSERT
                Assert.IsTrue(endsWithNewLine);
            }
            #endregion
        }
    }
    
