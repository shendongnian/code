    var encodingBasicReservedUnit = _dataContext.EncodingReservedUnits.FirstOrDefault();
            var initialReservedUnitCount = encodingBasicReservedUnit.CurrentReservedUnits;
            encodingBasicReservedUnit.CurrentReservedUnits = encodingBasicReservedUnit.MaxReservableUnits;
            encodingBasicReservedUnit.Update();
            encodingBasicReservedUnit = _dataContext.EncodingReservedUnits.FirstOrDefault();
            Assert.AreEqual(encodingBasicReservedUnit.CurrentReservedUnits, encodingBasicReservedUnit.MaxReservableUnits,
                "Expecting Encoding ReservedUnit to have increased to Max");
            encodingBasicReservedUnit.CurrentReservedUnits = initialReservedUnitCount;
            encodingBasicReservedUnit.Update();
            encodingBasicReservedUnit = _dataContext.EncodingReservedUnits.FirstOrDefault();
            Assert.AreEqual(encodingBasicReservedUnit.CurrentReservedUnits, initialReservedUnitCount,
                "Expecting Encoding ReservedUnit to have decreased again to initialCount from Max");
