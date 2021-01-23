	using FluentAssertions;
	using ReactiveUI.Subjects;
	using System;
	using System.Collections.Immutable;
	using System.Collections.Specialized;
	using System.Reactive.Disposables;
	using System.Reactive.Linq;
	using System.Reactive.Subjects;
	using Xunit;
	
	namespace ReactiveUI.Ext.Spec
	{
	    public class Data : Immutable
	    {
	        public int A { get; private set; }
	        public int B { get; private set; }
	
	        public  bool Equals(Data other){
	            return A == other.A && B == other.B;
	        }
	        public  bool Equals(object o){
	            Data other = o as Data;
	            if ( other == null )
	            {
	                return false;
	            }
	            return this.Equals(other);
	        }
	
	        public static bool operator ==( Data a, Data b )
	        {
	            return a.Equals(b);
	        }
	        public static bool operator !=( Data a, Data b )
	        {
	            return !a.Equals(b);
	        }
	
	        public Data( int a, int b )
	        {
	            A = a;
	            B = b;
	        }
	    }
	
	    public class DataMutable : ReactiveObject, IDisposable
	    {
	        int _A;
	        public int A
	        {
	            get { return _A; }
	            set { this.RaiseAndSetIfChanged(ref _A, value); }
	        }
	        int _B;
	        public int B
	        {
	            get { return _B; }
	            set { this.RaiseAndSetIfChanged(ref _B, value); }
	        }
	
	        IDisposable _Subscriptions;
	        public DataMutable( ILens<Data> dataLens )
	        {
	            _Subscriptions = new CompositeDisposable();
	            var d0 = dataLens.Focus(p => p.A).TwoWayBindTo(this, p => p.A);
	            var d1 = dataLens.Focus(p => p.B).TwoWayBindTo(this, p => p.B);
	            _Subscriptions = new CompositeDisposable(d0, d1);
	        }
	
	        public void Dispose()
	        {
	            _Subscriptions.Dispose();
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
	        public void ReactiveListSux()
	        {
	            var a = new ReactiveList<int>();
	            var b = a.CreateDerivedCollection(x => x);
	
	            a.Add(10);
	            b.Count.Should().Be(1);
	            
	        }
	
	
	        [Fact]
	        public void ShouldWork()
	        {
	            Fixture = ImmutableList<Data>.Empty;
	
	            // Convert an INPC property to a subject
	            ISubject<ImmutableList<Data>> s = this.PropertySubject(p => p.Fixture);
	
	            var MutableList = new ImmutableListToReactive<Data>(s);
	
	            var DerivedList = MutableList.CreateDerivedCollection(x => x);
	
	            Fixture = Fixture.Add(new Data(10, 20));
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	
	            Fixture = Fixture.Add(new Data(11, 21));
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	
	            Fixture = Fixture.Add(new Data(12, 22));
	            MutableList.Count.Should().Be(3);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            MutableList.Add(new Data(33, 88));
	            MutableList.Count.Should().Be(4);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            MutableList[1] = new Data(99, 21);
	            MutableList.Count.Should().Be(4);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            var itemAtOne = MutableList[1];
	            MutableList.RemoveAt(1);
	            MutableList.Should().NotContain(itemAtOne);
	            MutableList.Count.Should().Be(3);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            var i = new Data(78, 32);
	            MutableList.Insert(0, i);
	            DerivedList[0].Should().Be(i);
	            MutableList.Count.Should().Be(4);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            var j = new Data(18, 22);
	            MutableList.Insert(3, j);
	            DerivedList[3].Should().Be(j);
	            MutableList.Count.Should().Be(5);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            var k = new Data(18, 22);
	            MutableList.Add(k);
	            DerivedList[DerivedList.Count-1].Should().Be(k);
	            MutableList.Count.Should().Be(6);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	            MutableList.Remove(i);
	            DerivedList[DerivedList.Count-1].Should().Be(k);
	            MutableList.Count.Should().Be(5);
	            DerivedList.ShouldAllBeEquivalentTo(Fixture);
	            MutableList.ShouldAllBeEquivalentTo(Fixture);
	
	        }
	
	    }
	}
