    [TestMethod]
    public void EXAMPLE()
    {
        using (var container = new UnityAutoMoqContainer())
        {
            //(SNIP)
            var serviceMock = container.GetMock<ITreatmentPlanService>();
            var resetEvent = new ManualResetEventSlim();
            serviceMock.Setup(x=>x.GetSinglePatientViewTable(dateWindow, currentPatient, false))
                .Returns(() =>
                {
                    resetEvent.Set();
                    return new ObservableCollection<SinglePatientViewDataRow>();
                });
            var viewModel = container.Resolve<SinglePatientViewModel>();
            //(SNIP)
            viewModel.PatientsHadTPClosed(guids, Guid.NewGuid());
            waited = resetEvent.Wait(timeout);
            if(!waited)
                Assert.Fail("GetSinglePatientViewTable was not called within the timeout of {0} ms", timeout);
            //(SNIP)
            serviceMock.Verify(x => x.GetSinglePatientViewTable(dateWindow, currentPatient, false), Times.Once);
        }
    }
