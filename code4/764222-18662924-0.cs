    using System;
    using Machine.Fakes;
    using Machine.Specifications;
    
    namespace SOAnswers
    {
        [Subject(typeof(MailSender), "Sending an Email")]
        public class When_no_receivers_are_specified : WithSubject<MailSender>
        {
            static Exception exception;
    
            Because of = () =>
                exception = Catch.Exception(() => Subject.Send(string.Empty, string.Empty, receivers: null));
    
            It should_throw_an_exception = () =>
                exception.ShouldBeOfType<ArgumentException>();
        }
    }
