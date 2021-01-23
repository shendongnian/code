	namespace MyNamespace.Tests
	{
		using System;
		using NUnit.Framework;
		[SetUpFixture]
		public class TestsSetupClass
		{
			[SetUp]
			public void GlobalSetup()
			{
				// Do login here.
			}
			[TearDown]
			public void GlobalTeardown()
			{
				// Do logout here
			}
		}
	}
