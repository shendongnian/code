        [Test]
        public void Should_render()
        {
            var controlToTest = new TestingMyControl();
            var drawingGroup = controlToTest.Render();
            var drawing = drawingGroup.Children[0] as GeometryDrawing;
            Assert.That(drawing.Brush, Is.EqualTo(Brushes.Black));
            Assert.That(drawing.Pen.Brush, Is.EqualTo(Brushes.SeaGreen));
            Assert.That(drawing.Pen.Thickness, Is.EqualTo(0.6));
            Assert.That(drawing.Bounds.X, Is.EqualTo(5));
            Assert.That(drawing.Bounds.Y, Is.EqualTo(15));
            Assert.That(drawing.Bounds.Width, Is.EqualTo(25));
            Assert.That(drawing.Bounds.Height, Is.EqualTo(35));
        }
