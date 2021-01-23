        [TestMethod]
        public async Task Converter_With_Dependency_Property_Test()
        {
            var expectedResult = 3;
            var valueConverted = 0;
            await ExecuteOnUIThread(() =>
            {
                _converterWithDependencyProperty = new ConverterWithDependencyProperty();
                _converterWithDependencyProperty.DependencyProperty = _dummyValue;
                valueConverted = (int)_converterWithDependencyProperty.Convert(_dummyValueToConvert, typeof(int), null, null);
            });
            Assert.AreEqual(expectedResult, valueConverted);
        }
        public static IAsyncAction ExecuteOnUIThread(DispatchedHandler action)
        {
            return CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, action);
        }
