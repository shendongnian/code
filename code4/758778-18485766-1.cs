	namespace MyNamespace.Tests
	{
		using System;
		using NUnit.Framework;
		[SetUpFixture]
		public class TestsSetupClass
		{
			[SetUp]
			GlobalSetup()
			{
				// Do login here.
			}
			[TearDown]
			GlobalTeardown()
			{
				// Do logout here
			}
		}
	}
