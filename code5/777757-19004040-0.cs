    IEnumerator<T> enumerator = MockRepository.GenerateStub<IEnumerator<T>>();
    enumerator.Stub(x => x.MoveNext()).Return(true);
    enumerator.Stub(x => x.Current).Return(MockRepository.GenerateStub<T>());
    enumerator.Stub(x => x.MoveNext()).Return(false);
    IEnumerable<T> collection = MockRepository.GenerateStub<IEnumerable<T>>();
    collection.Stub(x => x.GetEnumerator()).Return(enumerator);
