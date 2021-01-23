	using FluentAssertions;
	using ReactiveUI.Subjects;
	using System.Collections.Immutable;
	using System.Reactive.Subjects;
	using Xunit;
	
	namespace ReactiveUI.Ext.Spec
	{
	    public class Data : Immutable
	    {
	        public int A { get; private set; }
	        public int B { get; private set; }
	
	        public Data( int a, int b )
	        {
	            A = a;
	            B = b;
	        }
	    }
	
	    public class ImmutableListToReactiveSpec : ReactiveObject
	    {
	        ImmutableList<Data> _Fixture;
	        public ImmutableList<Data> Fixture
	        {
	            get { return _Fixture; }
	            set { this.RaiseAndSetIfChanged(ref _Fixture, value); }
	        }
	
	        [Fact]
	        public void ShouldWork()
	        {
	            Fixture = ImmutableList<Data>.Empty;
	
	            // Convert an INPC property to a subject
	            ISubject<ImmutableList<Data>> s = this.PropertySubject(p => p.Fixture);
	
	            var l = new ImmutableListToReactive<Data>(s);
	
	            Fixture = Fixture.Add(new Data(10, 20));
	            l.ShouldAllBeEquivalentTo(Fixture);
	
	            Fixture = Fixture.Add(new Data(11, 21));
	            l.ShouldAllBeEquivalentTo(Fixture);
	
	            Fixture = Fixture.Add(new Data(12, 22));
	            l.ShouldAllBeEquivalentTo(Fixture);
	
	            l.Add(new Data(33, 88));
	            l.ShouldAllBeEquivalentTo(Fixture);
	
	        }
	
	    }
	}
	
