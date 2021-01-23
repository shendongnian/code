    public class CandidateTextInfoSource
    {
      public CandidateTextInfoSource(User user,
                                     Candidate candidate,
                                     Portafolio portafolio)
      {
        this.User = user;
        this.Candidate = candidate;
        this.Portafolio = portafolio;
      }
      public User User { get; set; }
      public Candidate Candidate { get; set; }
      public Portafolio Portafolio { get; set; }
    }
    // ...
    CreateMap<CandidateTextInfoSource, CandidateTextInfo>()
      .ForMember(d => d.ProfilePicture, o => o.MapFrom(s => s.User.ProfilePicture)
       // ...
      .ForMember(d => d.Name, o => o.MapFrom(s => s.Candidate.Name)
       // And so on...
