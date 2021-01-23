            [TestMethod]
            public void TestMethod1()
            {
                var s1 = MockScreenWraper(1, 1, 1, 1);
                var s2 = MockScreenWraper(1, 3, 1, 1);
    
                var list = new List<ScreenBoundsWrapper> { s1, s2 };
    
                var mockScreenFactory = new Mock<ScreensFactory>();
                mockScreenFactory
                    .Setup(m => m.GetAllScreens())
                    .Returns(() => list);
    
                var factory = mockScreenFactory.Object;
    
                var screenAbove = s1.FindAllScreens(factory, ScreenSearchDirections.Above);
    
                Assert.AreSame(screenAbove.First(), s2);
            }
    
            private static ScreenBoundsWrapper MockScreenWraper(int x, int y, int w, int h)
            {
                var mock = new Mock<ScreenBoundsWrapper>();
                mock.SetupGet(m => m.Bounds)
                    .Returns(() => new Rectangle(x, y, w, h));
    
                mock.Setup(m => m.Equals(It.IsAny<ScreenBoundsWrapper>()))
                    .Returns<ScreenBoundsWrapper>(
                        o => ReferenceEquals(mock.Object, o));
    
                return mock.Object;
            }
    
    }
