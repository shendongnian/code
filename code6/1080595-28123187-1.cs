    [Test]
    public void ReparentingShouldNotFail()
    {
        FillDb();
        using ( ISession session = OpenSession() )
        {
            var parent1 = session.Get<Parent>(1);
            var parent2 = session.Get<Parent>(2);
    
            Assert.AreEqual(1, parent1.Children.Count);
            Assert.AreEqual(0, parent2.Children.Count);
    
            Child p1Child = parent1.Children[0];
    
            Assert.IsNotNull(p1Child);
    
            parent1.DetachAllChildren();
            parent2.AttachNewChild(p1Child);
    
            session.Update(parent1);
            session.Update(parent2);
    
            // NHibernate.ObjectDeletedException : 
            // deleted object would be re-saved by cascade 
            // (remove deleted object from associations)
            // [NHibernate.Test.NHSpecificTest.NH1531.Child#0]
    
            session.Flush();
        }
        ...
